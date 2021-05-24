// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module as Layer1Module } from 'src/Layer1/Module';
import { Module as Layer5Module } from 'src/Layer5/Module';
import { DummyMainListPageGetQueryHandler } from './Queries/Get/DummyMainListPageGetQueryHandler';
import { DummyMainListPageModule } from './DummyMainListPageModule';
import { DummyMainListPageService } from './DummyMainListPageService';
import { DummyMainListPageStore } from './DummyMainListPageStore';

/**
 * Использовать страницу сущностей "DummyMain".
 */
export function useLayer5DummyMainListPage(
  module: DummyMainListPageModule,
  moduleOfLayer5: Layer5Module,
  moduleOfLayer1: Layer1Module
) {
  useLayer5DummyMainListPageGetQueryHandler(module, () => {
    return new DummyMainListPageGetQueryHandler(
      moduleOfLayer1.httpService,
      moduleOfLayer5.service,
      moduleOfLayer1.urlService
    );
  });

  let service: DummyMainListPageService;

  useLayer5DummyMainListPageService(module, () => {
    if (!service) {
      service = new DummyMainListPageService(module.getQueryHandler);
    }

    return service;
  });

  let store: DummyMainListPageStore;

  useLayer5DummyMainListPageStore(module, () => {
    if (!store) {
      store = new DummyMainListPageStore(
        module.service,
        moduleOfLayer1.timingFactory
      );
    }

    return store;
  });
}

/**
 * Использовать обработчик запроса на получение страницы сущностей "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5DummyMainListPageGetQueryHandler(
  module: DummyMainListPageModule,
  getter?: () => DummyMainListPageGetQueryHandler
) {
  if (getter) {
    module.getQueryHandlerGetter = getter;
  }

  return module.getQueryHandler;
}

/**
 * Использовать сервис страницы сущностей "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5DummyMainListPageService(
  module: DummyMainListPageModule,
  getter?: () => DummyMainListPageService
) {
  if (getter) {
    module.serviceGetter = getter;
  }

  return module.service;
}

/**
 * Использовать хранилище страницы сущностей "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Хранилище.
 */
export function useLayer5DummyMainListPageStore(
  module: DummyMainListPageModule,
  getter?: () => DummyMainListPageStore
) {
  if (getter) {
    module.storeGetter = getter;
  }

  return module.store;
}
