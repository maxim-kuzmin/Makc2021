// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useContext, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Context } from 'src/Context';

/**
 * Использовать ключ текущего пункта меню.
 * @param currentMenuItemKey Ключ текущего пункта меню.
 */
export function useCurrentMenuItemKey(currentMenuItemKey: string) {
  const contextValue = useContext(Context);

  const store = contextValue.Layer5.Controls.Menus.Top.getModule().store;

  const dispatch = useDispatch();

  const previousItemKeyOfTopMenuControl = useSelector(
    store.selectCurrentItemKey
  );

  useEffect(() => {
    if (currentMenuItemKey !== previousItemKeyOfTopMenuControl) {
      dispatch(store.setCurrentItemKeyAsync(currentMenuItemKey));
    }
  }, [currentMenuItemKey, dispatch, previousItemKeyOfTopMenuControl, store]);
}
