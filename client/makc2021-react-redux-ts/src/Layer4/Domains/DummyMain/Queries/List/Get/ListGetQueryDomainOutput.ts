// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createListGetQueryOutput,
  ListGetQueryOutput
} from 'src/Layer2/Queries/List/Get/ListGetQueryOutput';
import { ItemGetQueryDomainOutput } from '../../Item/Get/ItemGetQueryDomainOutput';

/**
 * Выходные данные запроса на получение списка в домене.
 */
export interface ListGetQueryDomainOutput
  extends ListGetQueryOutput<ItemGetQueryDomainOutput> {}

/**
 * Создать выходные данные запроса на получение списка в домене.
 * @returns Выходные данные запроса на получение списка в домене.
 */
export function createListGetQueryDomainOutput() {
  return {
    ...createListGetQueryOutput<ItemGetQueryDomainOutput>()
  } as ListGetQueryDomainOutput;
}
