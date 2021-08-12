// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useContext } from 'react';
import { Context } from 'src/Context';
import { useDispatch, useSelector } from 'react-redux';

/**
 * Использовать фокус.
 * @param id Идентификатор.
 * @returns Свойства компонента.
 */
export function useFocus(id: string) {
  const contextValue = useContext(Context);

  const storeOfFocusBehaviour =
    contextValue.Layer5.Behaviours.Focus.getModule().store;

  const idFromStore = useSelector(storeOfFocusBehaviour.selectId);

  const dispatch = useDispatch();

  const onFocus = () => {
    dispatch(storeOfFocusBehaviour.setId(id));
  };

  const onBlur = () => {
    dispatch(storeOfFocusBehaviour.clear());
  };

  return {
    autoFocus: id === idFromStore,
    key: id,
    onFocus,
    onBlur
  };
}
