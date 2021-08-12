// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useCallback, useContext, useEffect, useMemo } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useLocation } from 'react-router';
import { Link } from 'react-router-dom';
import { Column, Filters } from 'react-table';
import { Context } from 'src/Context';
import { useResource } from 'src/Layer1/Localization/LocalizationHooks';
import { createUrlParts } from 'src/Layer1/Url/UrlParts';
import { createDummyMainListPageGetQueryInput } from 'src/Layer5/Pages/DummyMain/List/Queries/Get/DummyMainListPageGetQueryInput';
import { DefaultTableControl } from 'src/Layer6/Controls/Tables/Default/DefaultTableControl';
import {
  createDummyMainListPageTableRow,
  DummyMainListPageTableRow
} from './Table/DummyMainListPageTableRow';
import { useCurrentMenuItemKey } from 'src/Layer6/Controls/Menus/Top/TopMenuControlHooks';
import { useQueryNotification } from 'src/Layer6/Controls/Notifications/Query/QueryNotificationControlHooks';

const tableId = 'DummyMainList';

const columnAccessorForAction = 'action';
const columnAccessorForId = 'id';
const columnAccessorForName = 'name';

const columnIdForAction = `${tableId}-${columnAccessorForAction}`;
const columnIdForId = `${tableId}-${columnAccessorForId}`;
const columnIdForName = `${tableId}-${columnAccessorForName}`;

function getColumnAccessorById(columnId: string) {
  switch (columnId) {
    case columnIdForId:
      return columnAccessorForId;
    case columnIdForName:
      return columnAccessorForName;
    default:
      return '';
  }
}

function getColumnIdByAccessor(columnAccessor: string) {
  switch (columnAccessor) {
    case columnAccessorForId:
      return columnIdForId;
    case columnAccessorForName:
      return columnIdForName;
    default:
      return '';
  }
}

/**
 * Страница сущностей "DummyMain".
 */
export function DummyMainListPage() {
  const contextValue = useContext(Context);

  const resource = useResource(
    contextValue.Layer6.Pages.DummyMain.List.getModule().createResource,
    'Layer6/Pages/DummyMain/List/DummyMainListPage'
  );

  const store = contextValue.Layer5.Pages.DummyMain.List.getModule().store;

  const serviceOfTopMenuControl =
    contextValue.Layer6.Controls.Menus.Top.getModule().service;

  useCurrentMenuItemKey(serviceOfTopMenuControl.itemOfAppDummyMainListPage.key);

  const storeOfQueryNotification =
    contextValue.Layer5.Controls.Notifications.Query.getModule().store;

  const urlService = contextValue.Layer1.getModule().urlService;

  const dispatch = useDispatch();

  const clearStore = useCallback(() => {
    dispatch(store.clear());

    dispatch(storeOfQueryNotification.clear());
  }, [dispatch, store, storeOfQueryNotification]);

  const location = useLocation();

  const search = useMemo(
    () => urlService.parseSearch(location.search),
    [urlService, location.search]
  );

  const pageNumber = Number(search.pn ?? '1');
  const pageSize = Number(search.ps ?? '10');
  const sortDirection = search.sd ?? 'desc';
  const sortField = search.sf ?? columnAccessorForId;
  const entityName = search.en;

  const filters = [
    {
      id: columnIdForName,
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

    dispatch(store.loadAsync(input));

    return () => clearStore();
  }, [
    pageNumber,
    pageSize,
    dispatch,
    store,
    sortDirection,
    sortField,
    entityName,
    clearStore
  ]);

  const getQueryResult = useSelector(store.selectGetQueryResult);

  useQueryNotification(getQueryResult);

  const { isOk, output } = getQueryResult;

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
        if (filter.id === columnIdForName) {
          entityName = filter.value;
        }
      }

      search.en = entityName;

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

      urlParts.search = search;

      return urlService.createUrl(urlParts);
    },
    [location.pathname, search, urlService]
  );

  const columns = useMemo(
    () =>
      [
        {
          id: columnIdForAction,
          Header: '',
          accessor: columnAccessorForAction,
          disableFilters: true,
          Cell: (e) => (
            <Link to={`/dummy-main/item/${e.row.values[columnIdForId]}`}>
              {resource.getViewLinkTitle()}
            </Link>
          ),
          minWidth: '6em'
        },
        {
          id: columnIdForId,
          Header: resource.getIDColumnTitle(),
          accessor: columnAccessorForId,
          disableFilters: true,
          minWidth: '5em'
        },
        {
          id: columnIdForName,
          Header: resource.getNameColumnTitle(),
          accessor: columnAccessorForName,
          width: '100%'
        }
      ] as Column<DummyMainListPageTableRow>[],
    [resource]
  );

  const data = useMemo(() => {
    return isOk
      ? output.list.items.map((item) => {
          const result = createDummyMainListPageTableRow();

          const { objectOfDummyMainEntity: entity } = item;

          result.id = entity.id;
          result.name = entity.name;

          return result;
        })
      : [];
  }, [isOk, output?.list.items]);

  let totalCount = useMemo(() => {
    return isOk ? output.list.totalCount : 0;
  }, [isOk, output?.list.totalCount]);

  return isOk ? (
    <DefaultTableControl
      columns={columns}
      data={data}
      filters={filters}
      pageNumber={pageNumber}
      pageSize={pageSize}
      sortDirection={sortDirection}
      sortField={sortField}
      sortFieldColumnId={getColumnIdByAccessor(sortField)}
      totalCount={totalCount}
      createPageUrl={createPageUrl}
      getSortFieldByColumnId={getColumnAccessorById}
    />
  ) : null;
}
