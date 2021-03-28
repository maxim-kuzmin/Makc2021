// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ItemGetQueryInput } from 'src/Layer2/Queries/Item/Get/ItemGetQueryInput';

/**
 * Входные данные запроса на получение элемента в домене.
 */
export interface ItemGetQueryDomainInput extends ItemGetQueryInput {
  /**
   * Имя сущности.
   */
  entityName: string;
}
