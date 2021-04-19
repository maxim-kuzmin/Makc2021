// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useCallback, useEffect, useMemo } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useLocation } from 'react-router';
import { Link } from 'react-router-dom';
import { Column, Filters } from 'react-table';
import { useLayer1UrlService } from 'src/Layer1/Hooks';
import { createUrlParts } from 'src/Layer1/Url/UrlParts';
import { useLayer5DummyMainListPageStore } from 'src/Layer5/Pages/DummyMain/List/DummyMainListPageHooks';
import { createDummyMainListPageGetQueryInput } from 'src/Layer5/Pages/DummyMain/List/Queries/Get/DummyMainListPageGetQueryInput';
import { GlobalWaitingControl } from 'src/Layer6/Controls/Waitings/Global/GlobalWaitingControl';
import { DefaultTableControl } from 'src/Layer6/Controls/Tables/Default/DefaultTableControl';
import { QueryErrorControl } from 'src/Layer6/Controls/Errors/Query/QueryErrorControl';
import {
  createDummyMainListPageTableRow,
  DummyMainListPageTableRow
} from './Table/DummyMainListPageTableRow';

/**
 * Страница сущностей "DummyMain".
 */
export function DummyMainListPage() {
  const storeOfDummyMainListPage = useLayer5DummyMainListPageStore();

  const urlService = useLayer1UrlService();

  const dispatch = useDispatch();

  const location = useLocation();

  const search = useMemo(() => urlService.parseSearch(location.search), [
    urlService,
    location.search
  ]);

  const pageNumber = Number(search.pn ?? '1');
  const pageSize = Number(search.ps ?? '10');
  const sortDirection = search.sd ?? 'desc';
  const sortField = search.sf ?? 'id';
  const entityName = search.en;

  const filters = [
    {
      id: 'name',
      value: entityName
    }
  ] as Filters<DummyMainListPageTableRow>;

  useEffect(() => {
    const input = createDummyMainListPageGetQueryInput();

    const { list } = input;

    list.pageNumber = pageNumber;
    list.pageSize = pageSize;
    list.sortDirection = sortDirection;
    list.sortField = sortField;
    list.entityName = entityName;

    dispatch(storeOfDummyMainListPage.loadAsync(input));
  }, [
    pageNumber,
    pageSize,
    dispatch,
    storeOfDummyMainListPage,
    sortDirection,
    sortField,
    entityName
  ]);

  const getQueryResult = useSelector(
    storeOfDummyMainListPage.selectGetQueryResult
  );

  const isWaiting = useSelector(storeOfDummyMainListPage.selectIsWaiting);

  const { isOk, errorMessages, output, queryCode } = getQueryResult;

  const createPageUrl = useCallback(
    (
      pageNumber: number,
      pageSize: number,
      sortDirection: string,
      sortField: string,
      filters: Filters<DummyMainListPageTableRow>
    ) => {
      const urlParts = createUrlParts();

      urlParts.path = location.pathname;

      let entityName: any;

      for (const filter of filters) {
        if (filter.id === 'name') {
          entityName = filter.value;
        }
      }

      const search: any = {};

      if (pageNumber) {
        search.pn = pageNumber;
      }

      if (pageSize) {
        search.ps = pageSize;
      }

      if (sortDirection) {
        search.sd = sortDirection;
      }

      if (sortField) {
        search.sf = sortField;
      }

      if (entityName) {
        search.en = entityName;
      }

      urlParts.search = search;

      return urlService.createUrl(urlParts);
    },
    [urlService, location.pathname]
  );

  const columns = useMemo(
    () =>
      [
        {
          Header: '',
          accessor: 'action',
          disableFilters: true,
          Cell: (e) => (
            <Link to={`/dummy-main/item/${e.row.values['id']}`}>Показать</Link>
          ),
          minWidth: '6em'
        },
        {
          Header: 'ID',
          accessor: 'id',
          disableFilters: true,
          minWidth: '5em'
        },
        {
          Header: 'Имя',
          accessor: 'name',
          width: '100%'
        }
      ] as Column<DummyMainListPageTableRow>[],
    []
  );

  let data: DummyMainListPageTableRow[];
  let totalCount = 0;

  if (isOk) {
    totalCount = output.list.totalCount;

    const { items } = output.list;

    data = items.map((item) => {
      const result = createDummyMainListPageTableRow();

      const { objectOfDummyMainEntity: entity } = item;

      result.id = entity.id;
      result.name = entity.name;

      return result;
    });
  } else {
    data = [];
  }

  return (
    <>
      <GlobalWaitingControl isVisible={isWaiting} />
      {!isOk && (
        <QueryErrorControl queryCode={queryCode} messages={errorMessages} />
      )}
      <DefaultTableControl
        columns={columns}
        data={data}
        filters={filters}
        loading={isWaiting}
        pageNumber={pageNumber}
        pageSize={pageSize}
        sortDirection={sortDirection}
        sortField={sortField}
        totalCount={totalCount}
        createPageUrl={createPageUrl}
      />
    </>
  );
}
