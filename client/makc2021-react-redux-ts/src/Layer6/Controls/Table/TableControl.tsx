// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useEffect, useMemo } from 'react';
import { Link, useHistory } from 'react-router-dom';
import {
  Column,
  useTable,
  usePagination,
  useSortBy,
  useFilters
} from 'react-table';
import { TextFilterControl } from '../Filters/Text/TextFilterControl';
import { TableControlProps } from './TableControlProps';

/**
 * Элемент управления "Таблица".
 * @template TRow Тип строки.
 * @returns HTML.
 */
export function TableControl<TRow extends object>({
  columns,
  data,
  createPageUrl,
  loading,
  pageNumber,
  pageSize,
  sortDirection,
  sortField,
  totalCount
}: React.PropsWithChildren<TableControlProps<TRow>>) {
  pageSize = normalizePageSize(pageSize);

  const pageCount = pageSize > 0 ? Math.ceil(totalCount / pageSize) : 1;

  pageNumber = normalizePageNumber(pageNumber, pageCount);

  const canPreviousPage = pageNumber > 1;
  const canNextPage = pageNumber < pageCount;

  const defaultColumn = useMemo(
    () =>
      ({
        Filter: TextFilterControl
      } as Column<TRow>),
    []
  );

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    prepareRow,
    page,
    state: { sortBy }
  } = useTable(
    {
      columns,
      data,
      defaultColumn,
      manualFilters: true,
      manualSortBy: true,
      disableMultiSort: true,
      disableSortRemove: true,
      manualPagination: true,
      initialState: {
        sortBy: [{ id: sortField, desc: sortDirection === 'desc' }]
      }
    },
    useFilters,
    useSortBy,
    usePagination
  );

  const history = useHistory();

  useEffect(() => {
    const sorting = sortBy[0];
    history.push(
      createPageUrl(
        pageNumber,
        pageSize,
        sorting.desc === true ? 'desc' : 'asc',
        sorting.id
      )
    );
  }, [createPageUrl, history, pageNumber, pageSize, sortBy]);

  function createPageLink(
    pageNumber: number,
    text: string,
    isClickable: boolean
  ) {
    pageNumber = normalizePageNumber(pageNumber, pageCount);

    return isClickable ? (
      <Link to={createPageUrl(pageNumber, pageSize, sortDirection, sortField)}>
        {text}
      </Link>
    ) : (
      <Link
        to={createPageUrl(pageNumber, pageSize, sortDirection, sortField)}
        onClick={(event) => event.preventDefault()}
        className="App-nonclickable"
      >
        {text}
      </Link>
    );
  }

  function goToPage(pageNumber: number, pageSize: number) {
    pageNumber = normalizePageNumber(pageNumber, pageCount);
    pageSize = normalizePageSize(pageSize);

    history.push(createPageUrl(pageNumber, pageSize, sortDirection, sortField));
  }

  // Render the UI for your table
  return (
    <>
      <table {...getTableProps()} style={{ border: 'solid 1px blue' }}>
        <thead>
          {headerGroups.map((headerGroup) => (
            <>
              <tr {...headerGroup.getHeaderGroupProps()}>
                {headerGroup.headers.map((column) => (
                  // Add the sorting props to control sorting. For this example
                  // we can add them into the header props
                  <th {...column.getHeaderProps(column.getSortByToggleProps())}>
                    {column.render('Header')}
                    {/* Add a sort direction indicator */}
                    <span>
                      {column.isSorted
                        ? column.isSortedDesc
                          ? ' 🔽'
                          : ' 🔼'
                        : ''}
                    </span>
                  </th>
                ))}
              </tr>
              <tr>
                {headerGroup.headers.map((column) => (
                  <th>
                    {/* Render the columns filter UI */}
                    <div>
                      {column.canFilter ? column.render('Filter') : null}
                    </div>
                  </th>
                ))}
              </tr>
            </>
          ))}
        </thead>
        <tbody {...getTableBodyProps()}>
          {page.map((row, i) => {
            prepareRow(row);
            return (
              <tr {...row.getRowProps()}>
                {row.cells.map((cell) => {
                  return (
                    <td
                      {...cell.getCellProps()}
                      style={{
                        padding: '10px',
                        border: 'solid 1px gray',
                        background: 'papayawhip'
                      }}
                    >
                      {cell.render('Cell')}
                    </td>
                  );
                })}
              </tr>
            );
          })}
          <tr>
            {loading ? (
              // Use our custom loading state to show a loading indicator
              <td colSpan={10000}>Loading...</td>
            ) : (
              <td colSpan={10000}>
                Showing {page.length} of ~{pageCount * pageSize} results
              </td>
            )}
          </tr>
        </tbody>
      </table>
      <div className="pagination">
        {createPageLink(1, '<<', canPreviousPage)}{' '}
        {createPageLink(pageNumber - 1, '<', canPreviousPage)}{' '}
        {createPageLink(pageNumber + 1, '>', canNextPage)}{' '}
        {createPageLink(pageCount, '>>', canNextPage)}
        <span>
          Page{' '}
          <strong>
            {pageNumber} of {pageCount}
          </strong>{' '}
        </span>
        <span>
          | Go to page:{' '}
          <input
            type="number"
            defaultValue={pageNumber}
            onChange={(e) => {
              const page = e.target.value ? Number(e.target.value) : 1;
              goToPage(page, pageSize);
            }}
            style={{ width: '100px' }}
          />
        </span>{' '}
        <select
          value={pageSize}
          onChange={(e) => {
            goToPage(1, Number(e.target.value));
          }}
        >
          {[1, 2, 3].map((pageSize) => (
            <option key={pageSize} value={pageSize}>
              Show {pageSize}
            </option>
          ))}
        </select>
      </div>
    </>
  );
}

function normalizePageNumber(pageNumber: number, pageCount: number) {
  if (pageNumber < 1) {
    pageNumber = 1;
  }

  if (pageNumber > pageCount) {
    pageNumber = pageCount;
  }

  return pageNumber;
}

function normalizePageSize(pageSize: number) {
  if (pageSize < 1) {
    pageSize = 0;
  }

  return pageSize;
}
