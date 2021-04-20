// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { PropsWithChildren, useEffect, useMemo } from 'react';
import Pagination from 'react-bootstrap/Pagination';
import Table from 'react-bootstrap/Table';
import { useHistory } from 'react-router-dom';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import {
  useTable,
  usePagination,
  useSortBy,
  useFilters,
  ColumnInterface
} from 'react-table';
import { TableColumnDefaultFilterControl } from '../../Table/Column/Filters/Default/TableColumnDefaultFilterControl';
import { DefaultTableControlProps } from './DefaultTableControlProps';
import { LinkContainer } from 'react-router-bootstrap';

/**
 * Элемент управления "Таблица по умолчанию".
 */
export function DefaultTableControl<TRow extends object>({
  columns,
  data,
  filters: controlledFilters,
  createPageUrl,
  loading,
  pageNumber,
  pageSize,
  sortDirection,
  sortField,
  totalCount
}: PropsWithChildren<DefaultTableControlProps<TRow>>) {
  pageSize = normalizePageSize(pageSize);

  const pageCount = pageSize > 0 ? Math.ceil(totalCount / pageSize) : 1;

  pageNumber = normalizePageNumber(pageNumber, pageCount);

  const canPreviousPage = pageNumber > 1;
  const canNextPage = pageNumber < pageCount;

  const defaultColumn = useMemo(
    () =>
      ({
        Filter: TableColumnDefaultFilterControl
      } as ColumnInterface<TRow>),
    []
  );

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    prepareRow,
    page,
    state: { sortBy, filters }
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
        filters: controlledFilters,
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
        sorting.id,
        filters
      )
    );
  }, [createPageUrl, history, pageNumber, pageSize, sortBy, filters]);

  function goToPage(pageNumber: number, pageSize: number) {
    pageNumber = normalizePageNumber(pageNumber, pageCount);
    pageSize = normalizePageSize(pageSize);

    history.push(
      createPageUrl(pageNumber, pageSize, sortDirection, sortField, filters)
    );
  }

  // Render the UI for your table
  return (
    <>
      <Table striped bordered hover size="sm" {...getTableProps()}>
        <thead>
          {headerGroups.map((headerGroup) => (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map((column) => (
                // Add the sorting props to control sorting. For this example
                // we can add them into the header props
                <th
                  {...column.getHeaderProps()}
                  style={{
                    verticalAlign: 'top',
                    width: column.width,
                    minWidth: column.minWidth
                  }}
                >
                  <div {...column.getSortByToggleProps()}>
                    {column.render('Header')}
                    {column.isSorted ? (
                      column.isSortedDesc ? (
                        <i className="bi bi-sort-down"></i>
                      ) : (
                        <i className="bi bi-sort-up"></i>
                      )
                    ) : (
                      ''
                    )}
                  </div>{' '}
                  <div>{column.canFilter ? column.render('Filter') : null}</div>
                </th>
              ))}
            </tr>
          ))}
        </thead>
        <tbody {...getTableBodyProps()}>
          {page.map((row, i) => {
            prepareRow(row);
            return (
              <tr {...row.getRowProps()}>
                {row.cells.map((cell) => {
                  return (
                    <td {...cell.getCellProps()}>{cell.render('Cell')}</td>
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
      </Table>
      <Pagination>
        <LinkContainer
          to={createPageUrl(1, pageSize, sortDirection, sortField, filters)}
        >
          <Pagination.First disabled={!canPreviousPage} />
        </LinkContainer>
        <LinkContainer
          to={createPageUrl(
            pageNumber - 1,
            pageSize,
            sortDirection,
            sortField,
            filters
          )}
        >
          <Pagination.Prev disabled={!canPreviousPage} />
        </LinkContainer>
        <LinkContainer
          to={createPageUrl(
            pageNumber + 1,
            pageSize,
            sortDirection,
            sortField,
            filters
          )}
        >
          <Pagination.Next disabled={!canNextPage} />
        </LinkContainer>
        <LinkContainer
          to={createPageUrl(
            pageCount,
            pageSize,
            sortDirection,
            sortField,
            filters
          )}
        >
          <Pagination.Last disabled={!canNextPage} />
        </LinkContainer>
      </Pagination>
      <Form>
        <Form.Group as={Row}>
          <Form.Label column style={{ whiteSpace: 'nowrap' }}>
            Page{' '}
            <strong>
              {pageNumber} of {pageCount}
            </strong>
          </Form.Label>
        </Form.Group>
        <Form.Group as={Row} controlId="page">
          <Form.Label column style={{ whiteSpace: 'nowrap' }}>
            Go to page
          </Form.Label>
          <Col>
            <Form.Control
              as="input"
              type="number"
              defaultValue={pageNumber + 1}
              onChange={(e) => {
                const page = e.target.value ? Number(e.target.value) : 1;
                goToPage(page, pageSize);
              }}
              style={{ width: '100px' }}
            />
          </Col>
        </Form.Group>
        <Form.Group as={Row}>
          <Form.Label column style={{ whiteSpace: 'nowrap' }}>
            Show
          </Form.Label>
          <Col>
            <Form.Control
              as="select"
              value={pageSize}
              onChange={(e) => {
                goToPage(1, Number(e.target.value));
              }}
              style={{ width: '100px' }}
            >
              <option>10</option>
              <option>20</option>
              <option>30</option>
            </Form.Control>
          </Col>
        </Form.Group>
      </Form>
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
