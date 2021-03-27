// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { createSlice } from '@reduxjs/toolkit';
import { createQueryResultWithOutput } from 'src/Layer1/Query/QueryResultWithOutput';
import { ItemGetQueryDomainOutput } from 'src/Layer4/Domains/DummyMain/Queries/Item/Get/ItemGetQueryDomainOutput';

const initialState = createQueryResultWithOutput<ItemGetQueryDomainOutput>();

const slice = createSlice({
  name: 'DummyMainItemPage',
  initialState,
  reducers: {}
});

export default slice.reducer;
