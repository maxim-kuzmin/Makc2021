// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { AppThunk, RootState } from 'src/Layer5/Store';
import { DummyMainItemPageService } from './DummyMainItemPageService';
import { createDummyMainItemPageState } from './DummyMainItemPageState';
import { DummyMainItemPageGetQueryInput } from './Queries/Get/DummyMainItemPageGetQueryInput';
import { DummyMainItemPageGetQueryOutput } from './Queries/Get/DummyMainItemPageGetQueryOutput';

/**
 * Хранилище страницы сущности "DummyMain".
 */
export class DummyMainItemPageStore {
  /**
   * Конструктор.
   * @param _appService Сервис.
   */
  constructor(private _appService: DummyMainItemPageService) {}

  /**
   * Загрузить асинхронно.
   * @param input Входные данные;
   * @returns Асинхронное действие.
   */
  loadAsync(input: DummyMainItemPageGetQueryInput): AppThunk {
    return async (dispatch) => {
      dispatch(wait(true));

      const result = await this._appService.get(input);

      dispatch(load(result));

      dispatch(wait(false));
    };
  }

  /**
   * Отобрать результат запроса на получение.
   * @param state Состояние.
   * @returns Результат запроса на получение.
   */
  selectGetQueryResult(state: RootState) {
    return state.ofDummyMainItemPage.getQueryResult;
  }

  /**
   * Отобрать признак нахождения в ожидании.
   * @param state Состояние.
   * @returns Признак нахождения в ожидании.
   */
  selectIsWaiting(state: RootState) {
    return state.ofDummyMainItemPage.isWaiting;
  }
}

const initialState = createDummyMainItemPageState();

const slice = createSlice({
  name: 'DummyMainItemPage',
  initialState,
  reducers: {
    load: (
      state,
      action: PayloadAction<
        QueryResultWithOutput<DummyMainItemPageGetQueryOutput>
      >
    ) => {
      state.getQueryResult = action.payload;
    },
    wait: (state, action: PayloadAction<boolean>) => {
      state.isWaiting = action.payload;
    }
  }
});

const { load, wait } = slice.actions;

export default slice.reducer;
