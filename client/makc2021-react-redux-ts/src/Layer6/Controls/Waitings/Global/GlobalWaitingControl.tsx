// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useContext, useEffect } from 'react';
import { SpinnerComponent } from 'react-element-spinner';
import { useDispatch, useSelector } from 'react-redux';
import { Context } from 'src/Context';

/**
 * Элемент управления "Глобальное ожидание".
 */
export function GlobalWaitingControl() {
  const contextValue = useContext(Context);

  const store = contextValue.Layer5.Controls.Waitings.Global.getModule().store;

  const dispatch = useDispatch();

  const isVisible = useSelector(store.selectIsVisible);

  useEffect(() => {
    return () => {
      dispatch(store.clear());
    };
  }, [dispatch, store]);

  return <SpinnerComponent loading={isVisible} position="global" />;
}
