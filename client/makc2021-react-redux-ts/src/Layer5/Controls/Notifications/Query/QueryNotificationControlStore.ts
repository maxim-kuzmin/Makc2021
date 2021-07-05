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
      dispatch(slice.actions.addQueryResult(queryResult));
    };
  }

  /**
   * Очистить.
   */
  clear() {
    return slice.actions.clear();
  }

  /**
   * Удалить асинхронно результат запроса по коду.
   * @param queryCode Код запроса.
   * @returns Асинхронное действие.
   */
  removeQueryResultByCodeAsync(queryCode: string): AppThunk {
    return async (dispatch) => {
      dispatch(slice.actions.removeQueryResultByCode(queryCode));
    };
  }

  /**
   * Отобрать результаты запросов.
   * @param state Состояние.
   * @returns Результаты запросов.
   */
  selectQueryResults(state: RootState) {
    return state.ofQueryNotificationControl.queryResults;
  }
}

const initialState = createQueryNotificationControlState();

const slice = createSlice({
  name: 'QueryNotificationControl',
  initialState,
  reducers: {
    clear: () => initialState,
    addQueryResult: (state, action: PayloadAction<QueryResult>) => {
      state.queryResults.push(action.payload);
    },
    removeQueryResultByCode: (state, action: PayloadAction<string>) => {
      const index = state.queryResults.findIndex(
        (queryResult) => queryResult.queryCode === action.payload
      );

      if (index > -1) {
        state.queryResults.splice(index, 1);
      }
    }
  }
});

export default slice.reducer;
