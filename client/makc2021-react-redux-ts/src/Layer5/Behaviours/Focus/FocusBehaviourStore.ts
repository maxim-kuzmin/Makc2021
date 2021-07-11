// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from 'src/Layer5/Store';
import { createFocusBehaviourState } from './FocusBehaviourState';

/**
 * Хранилище поведения фокуса.
 */
export class FocusBehaviourStore {
  /**
   * Очистить.
   * @returns Действие.
   */
  clear() {
    return slice.actions.clear();
  }

  /**
   * Отобрать идентификатор.
   * @param state Состояние.
   * @returns Идентификатор.
   */
  selectId(state: RootState) {
    return state.ofFocusBehaviour.id;
  }

  /**
   * Установить идентификатор.
   * @param id Идентификатор.
   * @returns Действие.
   */
  setId(id: string) {
    return slice.actions.setId(id);
  }
}

const initialState = createFocusBehaviourState();

const slice = createSlice({
  name: 'FocusBehaviour',
  initialState,
  reducers: {
    clear: () => initialState,
    setId: (state, action: PayloadAction<string>) => {
      state.id = action.payload;
    }
  }
});

export default slice.reducer;
