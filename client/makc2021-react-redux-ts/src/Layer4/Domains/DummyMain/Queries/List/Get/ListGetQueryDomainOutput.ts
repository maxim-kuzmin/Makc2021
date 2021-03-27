// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ListGetQueryOutput } from 'src/Layer2/Queries/List/Get/ListGetQueryOutput';
import { ItemGetQueryDomainOutput } from '../../Item/Get/ItemGetQueryDomainOutput';

/**
 * Выходные данные запроса на получение списка в домене.
 */
export interface ListGetQueryDomainOutput
  extends ListGetQueryOutput<ItemGetQueryDomainOutput> {}
