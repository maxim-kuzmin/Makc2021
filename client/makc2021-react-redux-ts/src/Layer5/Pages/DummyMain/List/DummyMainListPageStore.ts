// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { CommonStore } from 'src/Layer1/Common/CommonStore';
import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { TimingFactory } from 'src/Layer1/Timing/TimingFactory';
import { GlobalWaitingControlStore } from 'src/Layer5/Controls/Waitings/Global/GlobalWaitingControlStore';
import { AppThunk, RootState } from 'src/Layer5/Store';
import { DummyMainListPageService } from './DummyMainListPageService';
import { createDummyMainListPageState } from './DummyMainListPageState';
import { DummyMainListPageGetQueryInput } from './Queries/Get/DummyMainListPageGetQueryInput';
import { DummyMainListPageGetQueryOutput } from './Queries/Get/DummyMainListPageGetQueryOutput';

/**
 * Хранилище страницы сущностей "DummyMain".
 */
export class DummyMainListPageStore extends CommonStore {
  /**
   * Конструктор.
   * @param _appService Сервис.
   * @param _appGlobalWaitingControlStore Хранилище элемента управления "Глобальное ожидание".
   * @param appTimingFactory Фабрика согласования.
   */
  constructor(
    private _appService: DummyMainListPageService,
    private _appGlobalWaitingControlStore: GlobalWaitingControlStore,
    appTimingFactory: TimingFactory
  ) {
    super(appTimingFactory);
  }

  /**
   * Очистить.
   * @returns Действие.
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

      waiting.delay(() =>
        dispatch(this._appGlobalWaitingControlStore.setIsVisible(true))
      );

      const result = await this._appService.get(input);

      dispatch(slice.actions.load(result));

      waiting.prolong(() =>
        dispatch(this._appGlobalWaitingControlStore.setIsVisible(false))
      );
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
    }
  }
});

export default slice.reducer;
