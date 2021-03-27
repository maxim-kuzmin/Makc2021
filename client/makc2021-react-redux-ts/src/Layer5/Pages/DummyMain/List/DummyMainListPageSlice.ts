// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice } from '@reduxjs/toolkit';
import { createQueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { ListGetQueryDomainOutput } from 'src/Layer4/Domains/DummyMain/Queries/List/Get/ListGetQueryDomainOutput';

const initialState = createQueryResultWithOutput<ListGetQueryDomainOutput>();

const slice = createSlice({
  name: 'DummyMainListPage',
  initialState,
  reducers: {}
});

export default slice.reducer;
