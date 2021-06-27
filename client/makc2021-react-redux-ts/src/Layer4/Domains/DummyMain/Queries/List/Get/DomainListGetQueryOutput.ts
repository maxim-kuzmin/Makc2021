// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createListGetQueryOutput,
  ListGetQueryOutput
} from 'src/Layer2/Queries/List/Get/ListGetQueryOutput';
import { DomainItemGetQueryOutput } from '../../Item/Get/DomainItemGetQueryOutput';

/**
 * Выходные данные запроса на получение списка в домене.
 */
export interface DomainListGetQueryOutput
  extends ListGetQueryOutput<DomainItemGetQueryOutput> {}

/**
 * Создать выходные данные запроса на получение списка в домене.
 * @returns Выходные данные запроса на получение списка в домене.
 */
export function createDomainListGetQueryOutput() {
  return {
    ...createListGetQueryOutput<DomainItemGetQueryOutput>()
  } as DomainListGetQueryOutput;
}
