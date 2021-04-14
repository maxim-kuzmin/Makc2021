// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useParams } from 'react-router';
import { useLayer5DummyMainItemPageStore } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageHooks';
import { DummyMainItemPageParams } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageParams';
import { createDummyMainItemPageGetQueryInput } from 'src/Layer5/Pages/DummyMain/Item/Queries/Get/DummyMainItemPageGetQueryInput';

/**
 * Страница сущности "DummyMain".
 * @returns HTML.
 */
export function DummyMainItemPage() {
  const storeOfDummyMainItemPage = useLayer5DummyMainItemPageStore();

  const { id } = useParams<DummyMainItemPageParams>();

  const dispatch = useDispatch();

  useEffect(() => {
    const input = createDummyMainItemPageGetQueryInput();

    if (id) {
      input.item.entityId = Number(id);
    }

    dispatch(storeOfDummyMainItemPage.loadAsync(input));
  }, [id, dispatch, storeOfDummyMainItemPage]);

  let htmlOfId;
  let htmlOfEntity;
  let htmlOfErrors;
  let htmlOfWaiting;

  if (id) {
    htmlOfId = (
      <>
        <h3>Идентификатор:</h3>
        {id}
      </>
    );
  }

  const getQueryResult = useSelector(
    storeOfDummyMainItemPage.selectGetQueryResult
  );

  const isWaiting = useSelector(storeOfDummyMainItemPage.selectIsWaiting);

  if (isWaiting) {
    htmlOfWaiting = <h3>Идёт загрузка...</h3>;
  }

  const { isOk, errorMessages, output, queryCode } = getQueryResult;

  if (isOk) {
    const { objectOfDummyMainEntity: entity } = output.item;

    htmlOfEntity = (
      <>
        <h3>Имя:</h3>
        {entity.name}
      </>
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
      <h2>Сущность "DummyMain"</h2>
      {htmlOfId}
      {htmlOfWaiting}
      {htmlOfErrors}
      {htmlOfEntity}
    </>
  );
}
