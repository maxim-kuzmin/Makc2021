// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { CommonPageStore } from 'src/Layer1/Common/Page/CommonPageStore';
import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { TimingFactory } from 'src/Layer1/Timing/TimingFactory';
import { AppThunk, RootState } from 'src/Layer5/Store';
import { DummyMainItemPageService } from './DummyMainItemPageService';
import { createDummyMainItemPageState } from './DummyMainItemPageState';
import { DummyMainItemPageGetQueryInput } from './Queries/Get/DummyMainItemPageGetQueryInput';
import { DummyMainItemPageGetQueryOutput } from './Queries/Get/DummyMainItemPageGetQueryOutput';
import { DummyMainItemPageSaveQueryInput } from './Queries/Save/DummyMainItemPageSaveQueryInput';
import {
  createDummyMainItemPageStorePayloadForSave,
  DummyMainItemPageStorePayloadForSave
} from './Store/DummyMainItemPagePayloadForSave';

/**
 * Хранилище страницы сущности "DummyMain".
 */
export class DummyMainItemPageStore extends CommonPageStore {
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
  loadAsync(input: DummyMainItemPageGetQueryInput): AppThunk {
    return async (dispatch) => {
      const waiting = this.appTimingFactory.createWaiting();

      waiting.delay(() => dispatch(slice.actions.wait(true)));

      const result = await this._appService.get(input);

      dispatch(slice.actions.load(result));

      waiting.prolong(() => dispatch(slice.actions.wait(false)));
    };
  }

  /**
   * Сохранить асинхронно.
   * @param input Входные данные.
   * @returns Асинхронное действие.
   */
  saveAsync(input: DummyMainItemPageSaveQueryInput): AppThunk {
    return async (dispatch) => {
      const waiting = this.appTimingFactory.createWaiting();

      waiting.delay(() => dispatch(slice.actions.wait(true)));

      const result = await this._appService.save(input);

      dispatch(
        slice.actions.save(
          createDummyMainItemPageStorePayloadForSave(input, result)
        )
      );

      waiting.prolong(() => dispatch(slice.actions.wait(false)));
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

  /**
   * Отобрать входные данные запроса на сохранение.
   * @param state Состояние.
   * @returns Входные данные запроса на сохранение.
   */
  selectSaveQueryInput(state: RootState) {
    return state.ofDummyMainItemPage.saveQueryInput;
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
    save: (
      state,
      action: PayloadAction<DummyMainItemPageStorePayloadForSave>
    ) => {
      state.getQueryResult = action.payload.getQueryResult;
      state.saveQueryInput = action.payload.saveQueryInput;
    },
    wait: (state, action: PayloadAction<boolean>) => {
      state.isWaiting = action.payload;
    }
  }
});

export default slice.reducer;
