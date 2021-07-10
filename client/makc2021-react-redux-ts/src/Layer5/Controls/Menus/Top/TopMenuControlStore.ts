// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { AppThunk, RootState } from 'src/Layer5/Store';
import { createMenuControlState } from '../../../Control/Menu/MenuControlState';

/**
 * Хранилище элемента управления "Верхнее меню".
 */
export class TopMenuControlStore {
  /**
   * Очистить.
   * @returns Действие.
   */
  clear() {
    return slice.actions.clear();
  }

  /**
   * Отобрать ключ текущего пункта.
   * @param state Состояние.
   * @returns Ключ текущего пункта.
   */
  selectCurrentItemKey(state: RootState) {
    return state.ofTopMenuControl.currentItemKey;
  }

  /**
   * Установить ключ текущего пункта.
   * @param currentItemKey Ключ текущего пункта.
   * @returns Асинхронное действие.
   */
  setCurrentItemKeyAsync(currentItemKey: string): AppThunk {
    return async (dispatch) => {
      dispatch(slice.actions.setCurrentItemKey(currentItemKey));
    };
  }
}

const initialState = createMenuControlState();

const slice = createSlice({
  name: 'TopMenuControl',
  initialState,
  reducers: {
    clear: () => initialState,
    setCurrentItemKey: (state, action: PayloadAction<string>) => {
      state.currentItemKey = action.payload;
    }
  }
});

export default slice.reducer;
