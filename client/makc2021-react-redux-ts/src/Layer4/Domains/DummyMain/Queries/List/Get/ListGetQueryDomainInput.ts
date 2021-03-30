// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  createListGetQueryInput,
  ListGetQueryInput
} from 'src/Layer2/Queries/List/Get/ListGetQueryInput';

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

/**
 * Создать входные данные запроса на получение списка в домене.
 * @returns Входные данные запроса на получение списка в домене.
 */
export function createListGetQueryDomainInput(): ListGetQueryDomainInput {
  return {
    entityIds: [],
    entityIdsString: '',
    entityName: '',
    nameOfDummyOneToManyEntity: '',
    idOfDummyOneToManyEntity: 0,
    idsOfDummyOneToManyEntity: [],
    idsStringOfDummyOneToManyEntity: '',
    ...createListGetQueryInput()
  } as ListGetQueryDomainInput;
}
