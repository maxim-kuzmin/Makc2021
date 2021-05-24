// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module as Layer1Module } from 'src/Layer1/Module';
import { Module as Layer5Module } from 'src/Layer5/Module';
import { DummyMainItemPageGetQueryHandler } from './Queries/Get/DummyMainItemPageGetQueryHandler';
import { DummyMainItemPageModule } from './DummyMainItemPageModule';
import { DummyMainItemPageService } from './DummyMainItemPageService';
import { DummyMainItemPageStore } from './DummyMainItemPageStore';

/**
 * Использовать страницу сущности "DummyMain".
 */
export function useLayer5DummyMainItemPage(
  module: DummyMainItemPageModule,
  moduleOfLayer5: Layer5Module,
  moduleOfLayer1: Layer1Module
) {
  useLayer5DummyMainItemPageGetQueryHandler(module, () => {
    return new DummyMainItemPageGetQueryHandler(
      moduleOfLayer1.httpService,
      moduleOfLayer5.service,
      moduleOfLayer1.urlService
    );
  });

  let service: DummyMainItemPageService;

  useLayer5DummyMainItemPageService(module, () => {
    if (!service) {
      service = new DummyMainItemPageService(module.getQueryHandler);
    }

    return service;
  });

  let store: DummyMainItemPageStore;

  useLayer5DummyMainItemPageStore(module, () => {
    if (!store) {
      store = new DummyMainItemPageStore(
        module.service,
        moduleOfLayer1.timingFactory
      );
    }

    return store;
  });
}

/**
 * Использовать обработчик запроса на получение страницы сущности "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5DummyMainItemPageGetQueryHandler(
  module: DummyMainItemPageModule,
  getter?: () => DummyMainItemPageGetQueryHandler
) {
  if (getter) {
    module.getQueryHandlerGetter = getter;
  }

  return module.getQueryHandler;
}

/**
 * Использовать сервис страницы сущности "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5DummyMainItemPageService(
  module: DummyMainItemPageModule,
  getter?: () => DummyMainItemPageService
) {
  if (getter) {
    module.serviceGetter = getter;
  }

  return module.service;
}

/**
 * Использовать хранилище страницы сущности "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Хранилище.
 */
export function useLayer5DummyMainItemPageStore(
  module: DummyMainItemPageModule,
  getter?: () => DummyMainItemPageStore
) {
  if (getter) {
    module.storeGetter = getter;
  }

  return module.store;
}
