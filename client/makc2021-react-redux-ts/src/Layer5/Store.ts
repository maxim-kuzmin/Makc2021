import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import counterReducer from '../features/counter/counterSlice';
import appDummyMainItemPage from './Pages/DummyMain/Item/DummyMainItemPageSlice';
import appDummyMainListPage from './Pages/DummyMain/List/DummyMainListPageSlice';

export const store = configureStore({
  reducer: {
    counter: counterReducer,
    appDummyMainItemPage,
    appDummyMainListPage
  }
});

export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
