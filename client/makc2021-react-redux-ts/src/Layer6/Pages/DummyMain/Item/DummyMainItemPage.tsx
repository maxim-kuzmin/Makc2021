// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useEffect, useMemo } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { useDispatch, useSelector } from 'react-redux';
import { useParams } from 'react-router';
import { createDummyMainEntityObject } from 'src/Layer3/Sample/Entities/DummyMainEntityObject';
import { useLayer5DummyMainItemPageStore } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageHooks';
import { DummyMainItemPageParams } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageParams';
import { createDummyMainItemPageGetQueryInput } from 'src/Layer5/Pages/DummyMain/Item/Queries/Get/DummyMainItemPageGetQueryInput';
import { GlobalWaitingControl } from 'src/Layer6/Controls/Waitings/Global/GlobalWaitingControl';
import { QueryErrorControl } from 'src/Layer6/Controls/Errors/Query/QueryErrorControl';
import { useLayer6DummyMainItemPageResource } from './DummyMainItemPageHooks';
import { Configurator } from 'src/Configurator';

/**
 * Страница сущности "DummyMain".
 */
export function DummyMainItemPage() {
  const resource = useLayer6DummyMainItemPageResource(
    Configurator.Layer6.Pages.DummyMain.Item.module,
    Configurator.Layer1.getModule()
  );

  const store = useLayer5DummyMainItemPageStore(
    Configurator.Layer5.Pages.DummyMain.Item
  );

  const { id } = useParams<DummyMainItemPageParams>();

  const entityId = Number(id);

  const dispatch = useDispatch();

  useEffect(() => {
    if (entityId > 0) {
      const input = createDummyMainItemPageGetQueryInput();

      input.item.entityId = entityId;

      dispatch(store.loadAsync(input));
    }

    return () => {
      dispatch(store.clearAsync());
    };
  }, [entityId, dispatch, store]);

  const getQueryResult = useSelector(store.selectGetQueryResult);

  const isWaiting = useSelector(store.selectIsWaiting);

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
              <Form.Label column>{resource.getIDFieldTitle()}</Form.Label>
              <Col>
                <Form.Control plaintext readOnly value={data.id} />
              </Col>
            </Form.Group>
          )}
          <Form.Group as={Row} controlId="name">
            <Form.Label column>{resource.getNameFieldTitle()}</Form.Label>
            <Col>
              <Form.Control
                type="text"
                placeholder={resource.getNameFieldPlaceholder()}
                defaultValue={data.name}
              />
            </Col>
          </Form.Group>
          <Button variant="primary" type="submit">
            {resource.getSaveButtonTitle()}
          </Button>
        </Form>
      )}
    </>
  );
}
