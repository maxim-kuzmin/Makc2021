// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ChangeEvent, FormEvent, useContext, useEffect, useRef } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { useDispatch, useSelector } from 'react-redux';
import { useParams } from 'react-router';
import { Context } from 'src/Context';
import { useResource } from 'src/Layer1/Localization/LocalizationHooks';
import { createDummyMainEntityObject } from 'src/Layer3/Sample/Entities/DummyMainEntityObject';
import { DummyMainItemPageParams } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageParams';
import { createDummyMainItemPageGetQueryInput } from 'src/Layer5/Pages/DummyMain/Item/Queries/Get/DummyMainItemPageGetQueryInput';
import { GlobalWaitingControl } from 'src/Layer6/Controls/Waitings/Global/GlobalWaitingControl';
import { QueryErrorMessageControl } from 'src/Layer6/Controls/Messages/Error/Query/QueryErrorMessageControl';
import { QuerySuccessMessageControl } from 'src/Layer6/Controls/Messages/Success/Query/QuerySuccessMessageControl';
import { useCurrentMenuItemKey } from 'src/Layer6/Controls/Menus/Top/TopMenuControlHooks';
import { createDummyMainItemPageSaveQueryInput } from 'src/Layer5/Pages/DummyMain/Item/Queries/Save/DummyMainItemPageSaveQueryInput';

/**
 * Страница сущности "DummyMain".
 */
export function DummyMainItemPage() {
  const contextValue = useContext(Context);

  const resource = useResource(
    contextValue.Layer6.Pages.DummyMain.Item.getModule().createResource,
    'Layer6/Pages/DummyMain/Item/DummyMainItemPage'
  );

  const serviceOfTopMenuControl = contextValue.Layer6.Controls.Menus.Top.getModule()
    .service;

  const store = contextValue.Layer5.Pages.DummyMain.Item.getModule().store;

  useCurrentMenuItemKey(serviceOfTopMenuControl.itemOfAppDummyMainItemPage.key);

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

  const saveQueryInput = useSelector(store.selectSaveQueryInput);

  const {
    errorMessages,
    isOk,
    output,
    queryCode,
    successMessages
  } = getQueryResult;

  const dataOfDummyMainEntity =
    output?.item?.objectOfDummyMainEntity ??
    saveQueryInput?.data?.objectOfDummyMainEntity;

  let objectOfDummyMainEntity = !dataOfDummyMainEntity
    ? createDummyMainEntityObject()
    : {
        ...dataOfDummyMainEntity
      };

  objectOfDummyMainEntity.id = entityId > 0 ? entityId : 0;

  const refToInputOfName = useRef<HTMLInputElement>(null);

  const clear = () => {
    if (refToInputOfName.current) {
      refToInputOfName.current.value = '';
    }

    dispatch(store.clearAsync());
  };

  const onChangeName = (event: ChangeEvent<HTMLInputElement>) => {
    objectOfDummyMainEntity.name = event.target.name;
  };

  const onSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const input = createDummyMainItemPageSaveQueryInput();

    input.data.objectOfDummyMainEntity = objectOfDummyMainEntity;

    dispatch(store.saveAsync(input));
  };

  return (
    <>
      <GlobalWaitingControl isVisible={isWaiting} />
      {!isOk && (
        <QueryErrorMessageControl
          queryCode={queryCode}
          messages={errorMessages}
        />
      )}
      {isOk && (
        <QuerySuccessMessageControl
          queryCode={queryCode}
          messages={successMessages}
        />
      )}
      <Form onSubmit={onSubmit}>
        {objectOfDummyMainEntity.id > 0 && (
          <Form.Group as={Row} controlId="id">
            <Form.Label column>{resource.getIDFieldTitle()}</Form.Label>
            <Col>
              <Form.Control
                plaintext
                readOnly
                value={objectOfDummyMainEntity.id}
              />
            </Col>
          </Form.Group>
        )}
        <Form.Group as={Row} controlId="name">
          <Form.Label column>{resource.getNameFieldTitle()}</Form.Label>
          <Col>
            <Form.Control
              type="text"
              placeholder={resource.getNameFieldPlaceholder()}
              defaultValue={objectOfDummyMainEntity.name}
              onChange={onChangeName}
              ref={refToInputOfName}
            />
          </Col>
        </Form.Group>
        <Button variant="success" type="submit">
          {resource.getSaveButtonTitle()}
        </Button>
        &nbsp;
        <Button variant="primary" type="button" onClick={clear}>
          {resource.getClearButtonTitle()}
        </Button>
      </Form>
    </>
  );
}
