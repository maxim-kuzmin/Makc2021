// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useParams } from 'react-router';
import { DummyMainItemPageParams } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageParams';
import {
  loadAsync,
  selectGetQueryResult,
  selectIsWaiting
} from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageSlice';
import { createDummyMainItemPageGetQueryInput } from 'src/Layer5/Pages/DummyMain/Item/Queries/Get/DummyMainItemPageGetQueryInput';

/**
 * Страница сущности "DummyMain".
 */
export function DummyMainItemPage() {
  const { id } = useParams<DummyMainItemPageParams>();

  const dispatch = useDispatch();

  useEffect(() => {
    const input = createDummyMainItemPageGetQueryInput();

    if (id) {
      input.item.entityId = Number(id);
    }

    dispatch(loadAsync(input));
  }, [id, dispatch]);

  let htmlOfId;
  let htmlOfEntity;
  let htmlOfErrors;
  let htmlOfWaiting;

  if (id) {
    htmlOfId = (
      <React.Fragment>
        <h3>Идентификатор:</h3>
        {id}
      </React.Fragment>
    );
  }

  const getQueryResult = useSelector(selectGetQueryResult);

  const isWaiting = useSelector(selectIsWaiting);

  if (isWaiting) {
    htmlOfWaiting = <h3>Идёт загрузка...</h3>;
  }

  const { isOk, errorMessages, output, queryCode } = getQueryResult;

  if (isOk) {
    const { objectOfDummyMainEntity: entity } = output.item;

    htmlOfEntity = (
      <React.Fragment>
        <h3>Имя:</h3>
        {entity.name}
      </React.Fragment>
    );
  } else if (errorMessages.length > 0) {
    htmlOfErrors = errorMessages.map((errorMessage) => (
      <li key={errorMessage}>{errorMessage}</li>
    ));

    htmlOfErrors = (
      <React.Fragment>
        <h3>Ошибки в запросе {queryCode}:</h3>
        <ul>{htmlOfErrors}</ul>
      </React.Fragment>
    );
  }

  return (
    <React.Fragment>
      <h2>Сущность "DummyMain"</h2>
      {htmlOfId}
      {htmlOfWaiting}
      {htmlOfErrors}
      {htmlOfEntity}
    </React.Fragment>
  );
}
