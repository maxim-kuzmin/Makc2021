// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { CommonStore } from 'src/Layer1/Common/CommonStore';
import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { TimingFactory } from 'src/Layer1/Timing/TimingFactory';
import { AppThunk, RootState } from 'src/Layer5/Store';
import { DummyMainItemPageService } from './DummyMainItemPageService';
import { createDummyMainItemPageState } from './DummyMainItemPageState';
import { DummyMainItemPageGetQueryInput } from './Queries/Get/DummyMainItemPageGetQueryInput';
import { DummyMainItemPageGetQueryOutput } from './Queries/Get/DummyMainItemPageGetQueryOutput';

/**
 * Хранилище страницы сущности "DummyMain".
 */
export class DummyMainItemPageStore extends CommonStore {
  /**
   * Конструктор.
   * @param _appService Сервис.
   * @param appTimingFactory Фабрика согласования.
   */
  constructor(
    private _appService: DummyMainItemPageService,
    appTimingFactory: TimingFactory
  ) {
    super(appTimingFactory);
  }

  /**
   * Очистить асинхронно.
   * @returns Асинхронное действие.
   */
  clearAsync(): AppThunk {
    return async (dispatch) => {
      dispatch(clear());
    };
  }

  /**
   * Загрузить асинхронно.
   * @param input Входные данные;
   * @returns Асинхронное действие.
   */
  loadAsync(input: DummyMainItemPageGetQueryInput): AppThunk {
    return async (dispatch) => {
      const waiting = this.appTimingFactory.createWaiting();

      waiting.delay(() => dispatch(wait(true)));

      const result = await this._appService.get(input);

      dispatch(load(result));

      waiting.prolong(() => dispatch(wait(false)));
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
    clear: () => initialState,
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

const { clear, load, wait } = slice.actions;

export default slice.reducer;
