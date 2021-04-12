// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useParams } from 'react-router';
import { DummyMainItemPageParams } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageParams';
import { createDummyMainItemPageGetQueryInput } from 'src/Layer5/Pages/DummyMain/Item/Queries/Get/DummyMainItemPageGetQueryInput';
import { Module as Layer5Module } from 'src/Layer5/Module';

/**
 * Страница сущности "DummyMain".
 * @returns HTML.
 */
export function DummyMainItemPage() {
  const { sliceOfDummyMainItemPage } = Layer5Module.get();

  const { id } = useParams<DummyMainItemPageParams>();

  const dispatch = useDispatch();

  useEffect(() => {
    const input = createDummyMainItemPageGetQueryInput();

    if (id) {
      input.item.entityId = Number(id);
    }

    dispatch(sliceOfDummyMainItemPage.loadAsync(input));
  }, [id, dispatch, sliceOfDummyMainItemPage]);

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
    sliceOfDummyMainItemPage.selectGetQueryResult
  );

  const isWaiting = useSelector(sliceOfDummyMainItemPage.selectIsWaiting);

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
