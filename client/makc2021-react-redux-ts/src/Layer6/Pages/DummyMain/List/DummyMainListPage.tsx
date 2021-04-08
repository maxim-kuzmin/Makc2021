// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useCallback, useMemo, useRef, useState } from 'react';
import { Column } from 'react-table';
import { TableControl } from 'src/Layer6/Controls/Table/TableControl';
import { DummyMainListPageTableRow } from './Table/DummyMainListPageTableRow';

/**
 * Страница сущностей "DummyMain".
 * @returns HTML.
 */
export function DummyMainListPage() {
  const serverData = useMemo(
    () =>
      [
        {
          col1: 'Hello',
          col2: 'World'
        },
        {
          col1: 'react-table',
          col2: 'rocks'
        },
        {
          col1: 'whatever',
          col2: 'you want'
        }
      ] as DummyMainListPageTableRow[],
    []
  );

  const columns = useMemo(
    () =>
      [
        {
          Header: 'Column 1',
          accessor: 'col1'
        },
        {
          Header: 'Column 2',
          accessor: 'col2'
        }
      ] as Column<DummyMainListPageTableRow>[],
    []
  );

  // We'll start our table without any data
  const [data, setData] = useState<DummyMainListPageTableRow[]>([]);
  const [loading, setLoading] = useState(false);
  const [pageCount, setPageCount] = useState(0);
  const fetchIdRef = useRef(0);

  const fetchData = useCallback(
    ({ pageSize, pageIndex }) => {
      // This will get called when the table needs new data
      // You could fetch your data from literally anywhere,
      // even a server. But for this example, we'll just fake it.

      // Give this fetch an ID
      const fetchId = ++fetchIdRef.current;

      // Set the loading state
      setLoading(true);

      // We'll even set a delay to simulate a server here
      setTimeout(() => {
        console.log(
          `fetchId=${fetchId}, fetchIdRef.current=${fetchIdRef.current}`
        );
        // Only update the data if this is the latest fetch
        if (fetchId === fetchIdRef.current) {
          const startRow = pageSize * pageIndex;
          const endRow = startRow + pageSize;
          setData(serverData.slice(startRow, endRow));

          // Your server could send back total page count.
          // For now we'll just fake it, too
          setPageCount(Math.ceil(serverData.length / pageSize));

          setLoading(false);
        }
      }, 1000);
    },
    [serverData]
  );

  return (
    <TableControl
      columns={columns}
      data={data}
      fetchData={fetchData}
      loading={loading}
      pageCount={pageCount}
    />
  );
}
