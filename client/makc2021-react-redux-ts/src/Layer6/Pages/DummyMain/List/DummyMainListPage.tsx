// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { useLocation } from 'react-router';
import { Column } from 'react-table';
import { useLayer1UrlService } from 'src/Layer1/Hooks';
import { createUrlParts } from 'src/Layer1/Url/UrlParts';
import { TableControl } from 'src/Layer6/Controls/Table/TableControl';
import { DummyMainListPageTableRow } from './Table/DummyMainListPageTableRow';

/**
 * Страница сущностей "DummyMain".
 * @returns HTML.
 */
export function DummyMainListPage() {
  const urlService = useLayer1UrlService();

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

  const location = useLocation();

  const query = useMemo(() => urlService.parseSearch(location.search), [
    urlService,
    location.search
  ]);

  const serverData = useMemo(
    () =>
      [
        {
          col1: '1',
          col2: '111'
        },
        {
          col1: '2',
          col2: '222'
        },
        {
          col1: '3',
          col2: '333'
        }
      ] as DummyMainListPageTableRow[],
    []
  );

  // We'll start our table without any data
  const [data, setData] = useState<DummyMainListPageTableRow[]>([]);
  const [loading, setLoading] = useState(false);
  const [totalCount, setTotalCount] = useState(0);
  const fetchIdRef = useRef(0);

  const pageNumber = Number(query['pn'] ?? '1');
  const pageSize = Number(query['ps'] ?? '1');

  useEffect(() => {
    // Give this fetch an ID
    const fetchId = ++fetchIdRef.current;

    // Set the loading state
    setLoading(true);

    // We'll even set a delay to simulate a server here
    setTimeout(() => {
      // Only update the data if this is the latest fetch
      if (fetchId === fetchIdRef.current) {
        const startRow = pageSize * (pageNumber - 1);
        const endRow = startRow + pageSize;
        setData(serverData.slice(startRow, endRow));

        setTotalCount(serverData.length);

        setLoading(false);
      }
    }, 1000);
  }, [pageNumber, pageSize, serverData]);

  const createPageUrl = useCallback(
    (pageNumber, pageSize) => {
      const urlParts = createUrlParts();

      urlParts.path = location.pathname;

      urlParts.search = {
        pn: pageNumber,
        ps: pageSize
      };

      return urlService.createUrl(urlParts);
    },
    [urlService, location.pathname]
  );

  return (
    <TableControl
      columns={columns}
      data={data}
      loading={loading}
      pageNumber={pageNumber}
      pageSize={pageSize}
      totalCount={totalCount}
      createPageUrl={createPageUrl}
    />
  );
}
