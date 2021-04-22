// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useEffect, useMemo } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { useTranslation } from 'react-i18next';
import { useDispatch, useSelector } from 'react-redux';
import { useParams } from 'react-router';
import { createDummyMainEntityObject } from 'src/Layer3/Sample/Entities/DummyMainEntityObject';
import { useLayer5DummyMainItemPageStore } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageHooks';
import { DummyMainItemPageParams } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageParams';
import { createDummyMainItemPageGetQueryInput } from 'src/Layer5/Pages/DummyMain/Item/Queries/Get/DummyMainItemPageGetQueryInput';
import { GlobalWaitingControl } from 'src/Layer6/Controls/Waitings/Global/GlobalWaitingControl';
import { QueryErrorControl } from 'src/Layer6/Controls/Errors/Query/QueryErrorControl';

/**
 * Страница сущности "DummyMain".
 */
export function DummyMainItemPage() {
  const { t } = useTranslation();

  const storeOfDummyMainItemPage = useLayer5DummyMainItemPageStore();

  const { id } = useParams<DummyMainItemPageParams>();

  const entityId = Number(id);

  const dispatch = useDispatch();

  useEffect(() => {
    if (entityId > 0) {
      const input = createDummyMainItemPageGetQueryInput();

      input.item.entityId = entityId;

      dispatch(storeOfDummyMainItemPage.loadAsync(input));
    }

    return () => {
      dispatch(storeOfDummyMainItemPage.clearAsync());
    };
  }, [entityId, dispatch, storeOfDummyMainItemPage]);

  const getQueryResult = useSelector(
    storeOfDummyMainItemPage.selectGetQueryResult
  );

  const isWaiting = useSelector(storeOfDummyMainItemPage.selectIsWaiting);

  const { errorMessages, output, queryCode } = getQueryResult;

  const isOk = !entityId || getQueryResult.isOk;

  const data = useMemo(() => {
    return getQueryResult.isOk
      ? output.item.objectOfDummyMainEntity
      : createDummyMainEntityObject();
  }, [getQueryResult.isOk, output?.item.objectOfDummyMainEntity]);

  return (
    <>
      <GlobalWaitingControl isVisible={isWaiting} />
      {!isOk && (
        <QueryErrorControl queryCode={queryCode} messages={errorMessages} />
      )}
      {isOk && (
        <Form>
          {data.id > 0 && (
            <Form.Group as={Row} controlId="id">
              <Form.Label column>{t('ID')}</Form.Label>
              <Col>
                <Form.Control plaintext readOnly value={data.id} />
              </Col>
            </Form.Group>
          )}
          <Form.Group as={Row} controlId="name">
            <Form.Label column>{t('Имя')}</Form.Label>
            <Col>
              <Form.Control
                type="text"
                placeholder={t('Введите имя')}
                defaultValue={data.name}
              />
            </Col>
          </Form.Group>
          <Button variant="primary" type="submit">
            {t('Сохранить')}
          </Button>
        </Form>
      )}
    </>
  );
}
