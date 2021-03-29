// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { QueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { AppThunk, RootState } from 'src/Layer5/Store';
import { get } from './DummyMainItemPageService';
import { createDummyMainItemPageState } from './DummyMainItemPageState';
import { DummyMainItemPageGetQueryInput } from './Queries/Get/DummyMainItemPageGetQueryInput';
import { DummyMainItemPageGetQueryOutput } from './Queries/Get/DummyMainItemPageGetQueryOutput';

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

export const { load, wait } = slice.actions;

export const loadAsync = (
  input: DummyMainItemPageGetQueryInput
): AppThunk => async (dispatch) => {
  dispatch(wait(true));

  const result = await get(input);

  dispatch(load(result));

  dispatch(wait(false));
};

export const selectGetQueryResult = (state: RootState) =>
  state.appDummyMainItemPage.getQueryResult;

export const selectIsWaiting = (state: RootState) =>
  state.appDummyMainItemPage.isWaiting;

export default slice.reducer;
