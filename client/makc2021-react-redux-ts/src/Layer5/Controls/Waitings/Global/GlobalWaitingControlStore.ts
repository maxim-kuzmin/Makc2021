// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { createWaitingControlState } from 'src/Layer5/Control/Waiting/WaitingControlState';
import { RootState } from 'src/Layer5/Store';

/**
 * Хранилище элемента управления "Глобальное ожидание".
 */
export class GlobalWaitingControlStore {
  /**
   * Очистить.
   * @returns Действие.
   */
  clear() {
    return slice.actions.clear();
  }

  /**
   * Отобрать признак видимости.
   * @param state Состояние.
   * @returns Признак видимости.
   */
  selectIsVisible(state: RootState) {
    return state.ofGlobalWaitingControl.isVisible;
  }

  /**
   * Установить признак видимости.
   * @param isVisible Признак видимости.
   * @returns Действие.
   */
  setIsVisible(isVisible: boolean) {
    return slice.actions.setIsVisible(isVisible);
  }
}

const initialState = createWaitingControlState();

const slice = createSlice({
  name: 'GlobalWaitingControl',
  initialState,
  reducers: {
    clear: () => initialState,
    setIsVisible: (state, action: PayloadAction<boolean>) => {
      state.isVisible = action.payload;
    }
  }
});

export default slice.reducer;
