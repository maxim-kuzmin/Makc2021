// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { CommonPageStore } from 'src/Layer1/Common/Page/CommonPageStore';
import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { TimingFactory } from 'src/Layer1/Timing/TimingFactory';
import { AppThunk, RootState } from 'src/Layer5/Store';
import { DummyMainListPageService } from './DummyMainListPageService';
import { createDummyMainListPageState } from './DummyMainListPageState';
import { DummyMainListPageGetQueryInput } from './Queries/Get/DummyMainListPageGetQueryInput';
import { DummyMainListPageGetQueryOutput } from './Queries/Get/DummyMainListPageGetQueryOutput';

/**
 * Хранилище страницы сущностей "DummyMain".
 */
export class DummyMainListPageStore extends CommonPageStore {
  /**
   * Конструктор.
   * @param _appService Сервис.
   * @param appTimingFactory Фабрика согласования.
   */
  constructor(
    private _appService: DummyMainListPageService,
    appTimingFactory: TimingFactory
  ) {
    super(appTimingFactory);
  }

  /**
   * Очистить.
   */
  clear() {
    return slice.actions.clear();
  }

  /**
   * Загрузить асинхронно.
   * @param input Входные данные.
   * @returns Асинхронное действие.
   */
  loadAsync(input: DummyMainListPageGetQueryInput): AppThunk {
    return async (dispatch) => {
      const waiting = this.appTimingFactory.createWaiting();

      waiting.delay(() => dispatch(slice.actions.wait(true)));

      const result = await this._appService.get(input);

      dispatch(slice.actions.load(result));

      waiting.prolong(() => dispatch(slice.actions.wait(false)));
    };
  }

  /**
   * Отобрать результат запроса на получение.
   * @param state Состояние.
   * @returns Результат запроса на получение.
   */
  selectGetQueryResult(state: RootState) {
    return state.ofDummyMainListPage.getQueryResult;
  }

  /**
   * Отобрать признак нахождения в ожидании.
   * @param state Состояние.
   * @returns Признак нахождения в ожидании.
   */
  selectIsWaiting(state: RootState) {
    return state.ofDummyMainListPage.isWaiting;
  }
}

const initialState = createDummyMainListPageState();

const slice = createSlice({
  name: 'DummyMainListPage',
  initialState,
  reducers: {
    clear: () => initialState,
    load: (
      state,
      action: PayloadAction<
        QueryResultWithOutput<DummyMainListPageGetQueryOutput>
      >
    ) => {
      state.getQueryResult = action.payload;
    },
    wait: (state, action: PayloadAction<boolean>) => {
      state.isWaiting = action.payload;
    }
  }
});

export default slice.reducer;
