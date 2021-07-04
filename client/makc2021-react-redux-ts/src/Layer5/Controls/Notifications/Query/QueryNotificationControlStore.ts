import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { QueryResult } from 'src/Layer1/Query/QueryResult';
import { AppThunk, RootState } from 'src/Layer5/Store';
import { createQueryNotificationControlState } from './QueryNotificationControlState';

/**
 * Хранилище элемента управления "Извещение запроса".
 */
export class QueryNotificationControlStore {
  /**
   * Добавить асинхронно результат запроса.
   * @param queryResult Результат запроса.
   * @returns Асинхронное действие.
   */
  addQueryResultAsync(queryResult: QueryResult): AppThunk {
    return async (dispatch) => {
      dispatch(addQueryResult(queryResult));
    };
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
   * Удалить асинхронно результат запроса по коду.
   * @param queryCode Код запроса.
   * @returns Асинхронное действие.
   */
  removeQueryResultByCodeAsync(queryCode: string): AppThunk {
    return async (dispatch) => {
      dispatch(removeQueryResultByCode(queryCode));
    };
  }

  /**
   * Отобрать карту результата запроса по коду.
   * @param state Состояние.
   * @returns Карта результата запроса по коду.
   */
  selectMapOfQueryResultByCode(state: RootState) {
    return state.ofQueryNotificationControl.mapOfQueryResultByCode;
  }
}

const initialState = createQueryNotificationControlState();

const slice = createSlice({
  name: 'QueryNotificationControl',
  initialState,
  reducers: {
    clear: () => initialState,
    addQueryResult: (state, action: PayloadAction<QueryResult>) => {
      state.mapOfQueryResultByCode.set(
        action.payload.queryCode,
        action.payload
      );
    },
    removeQueryResultByCode: (state, action: PayloadAction<string>) => {
      state.mapOfQueryResultByCode.delete(action.payload);
    }
  }
});

const { clear, addQueryResult, removeQueryResultByCode } = slice.actions;

export default slice.reducer;
