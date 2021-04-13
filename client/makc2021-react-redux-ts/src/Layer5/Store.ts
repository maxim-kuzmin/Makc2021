// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import ofDummyMainItemPage from './Pages/DummyMain/Item/DummyMainItemPageStore';
import ofDummyMainListPage from './Pages/DummyMain/List/DummyMainListPageStore';

export const store = configureStore({
  reducer: {
    ofDummyMainItemPage,
    ofDummyMainListPage
  }
});

export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
