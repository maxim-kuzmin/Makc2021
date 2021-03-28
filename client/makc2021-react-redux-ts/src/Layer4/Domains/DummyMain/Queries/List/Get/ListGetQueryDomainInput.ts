// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { ListGetQueryInput } from 'src/Layer2/Queries/List/Get/ListGetQueryInput';

/**
 * Входные данные запроса на получение списка в домене.
 */
export interface ListGetQueryDomainInput extends ListGetQueryInput {
  /**
   * Идентификаторы сущности.
   */
  entityIds: number[];

  /**
   * Строка идентификаторов сущности.
   */
  entityIdsString: string;

  /**
   * Имя сущности.
   */
  entityName: string;

  /**
   * Имя сущности "DummyOneToMany".
   */
  nameOfDummyOneToManyEntity: string;

  /**
   * Идентификатор сущности "DummyOneToMany".
   */
  idOfDummyOneToManyEntity: number;

  /**
   * Идентификаторы сущности "DummyOneToMany".
   */
  idsOfDummyOneToManyEntity: number[];

  /**
   * Строка идентификаторов сущности "DummyOneToMany".
   */
  idsStringOfDummyOneToManyEntity: string;
}
