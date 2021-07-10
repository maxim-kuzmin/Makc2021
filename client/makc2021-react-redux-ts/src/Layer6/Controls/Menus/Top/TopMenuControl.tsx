// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useEffect } from 'react';
import { useContext } from 'react';
import Nav from 'react-bootstrap/Nav';
import { useDispatch } from 'react-redux';
import { useLocation } from 'react-router-dom';
import { Context } from 'src/Context';
import { useResource } from 'src/Layer1/Localization/LocalizationHooks';
import { TopMenuItemControl } from './Item/TopMenuItemControl';

/**
 * Элемент управления "Верхнее меню".
 */
export function TopMenuControl() {
  const contextValue = useContext(Context);

  const resource = useResource(
    contextValue.Layer6.Controls.Menus.Top.getModule().createResource,
    'Layer6/Controls/Menus/Top/TopMenuControl'
  );

  const service = contextValue.Layer6.Controls.Menus.Top.getModule().service;

  const store = contextValue.Layer5.Controls.Menus.Top.getModule().store;

  service.loadResource(resource);

  const location = useLocation();

  const dispatch = useDispatch();

  useEffect(() => {
    return () => {
      dispatch(store.clear());
    };
  }, [dispatch, store]);

  return (
    <Nav className="justify-content-center" activeKey={location.pathname}>
      <TopMenuItemControl menuItem={service.itemOfAppDummyMainListPage} />
      <TopMenuItemControl menuItem={service.itemOfAppDummyMainItemPage} />
      <TopMenuItemControl menuItem={service.itemOfAppContactsPage} />
    </Nav>
  );
}
