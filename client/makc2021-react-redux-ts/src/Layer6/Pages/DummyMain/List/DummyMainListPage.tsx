// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useCallback, useEffect, useMemo } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useLocation } from 'react-router';
import { Column } from 'react-table';
import { useLayer1UrlService } from 'src/Layer1/Hooks';
import { createUrlParts } from 'src/Layer1/Url/UrlParts';
import { useLayer5DummyMainListPageStore } from 'src/Layer5/Pages/DummyMain/List/DummyMainListPageHooks';
import { createDummyMainListPageGetQueryInput } from 'src/Layer5/Pages/DummyMain/List/Queries/Get/DummyMainListPageGetQueryInput';
import { TableControl } from 'src/Layer6/Controls/Table/TableControl';
import {
  createDummyMainListPageTableRow,
  DummyMainListPageTableRow
} from './Table/DummyMainListPageTableRow';

/**
 * Страница сущностей "DummyMain".
 * @returns HTML.
 */
export function DummyMainListPage() {
  const storeOfDummyMainListPage = useLayer5DummyMainListPageStore();

  const urlService = useLayer1UrlService();

  const dispatch = useDispatch();

  const location = useLocation();

  const query = useMemo(() => urlService.parseSearch(location.search), [
    urlService,
    location.search
  ]);

  const pageNumber = Number(query.pn ?? '1');
  const pageSize = Number(query.ps ?? '10');

  useEffect(() => {
    const input = createDummyMainListPageGetQueryInput();

    input.list.pageNumber = pageNumber;
    input.list.pageSize = pageSize;

    dispatch(storeOfDummyMainListPage.loadAsync(input));
  }, [pageNumber, pageSize, dispatch, storeOfDummyMainListPage]);

  const getQueryResult = useSelector(
    storeOfDummyMainListPage.selectGetQueryResult
  );

  const isWaiting = useSelector(storeOfDummyMainListPage.selectIsWaiting);

  let htmlOfItems;
  let htmlOfErrors;

  const { isOk, errorMessages, output, queryCode } = getQueryResult;

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

  const columns = useMemo(
    () =>
      [
        {
          Header: 'Id',
          accessor: 'id'
        },
        {
          Header: 'Name',
          accessor: 'name'
        }
      ] as Column<DummyMainListPageTableRow>[],
    []
  );

  if (isOk) {
    const { totalCount, items } = output.list;

    const data = items.map((item) => {
      const result = createDummyMainListPageTableRow();

      const { objectOfDummyMainEntity: entity } = item;

      result.id = entity.id;
      result.name = entity.name;

      return result;
    });

    htmlOfItems = (
      <TableControl
        columns={columns}
        data={data}
        loading={isWaiting}
        pageNumber={pageNumber}
        pageSize={pageSize}
        totalCount={totalCount}
        createPageUrl={createPageUrl}
      />
    );
  } else if (errorMessages.length > 0) {
    htmlOfErrors = errorMessages.map((errorMessage) => (
      <li key={errorMessage}>{errorMessage}</li>
    ));

    htmlOfErrors = (
      <>
        <h3>Ошибки в запросе {queryCode}:</h3>
        <ul>{htmlOfErrors}</ul>
      </>
    );
  }

  return (
    <>
      <h2>Сущности "DummyMain"</h2>
      {htmlOfErrors}
      {htmlOfItems}
    </>
  );
}
