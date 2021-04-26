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
export function useLayer5DummyMainItemPage() {
  useLayer5DummyMainItemPageGetQueryHandler(() => {
    return new DummyMainItemPageGetQueryHandler(
      Layer1Module.get().httpService,
      Layer5Module.get().service,
      Layer1Module.get().urlService
    );
  });

  let service: DummyMainItemPageService;

  useLayer5DummyMainItemPageService(() => {
    if (!service) {
      service = new DummyMainItemPageService(
        DummyMainItemPageModule.get().getQueryHandler
      );
    }

    return service;
  });

  let store: DummyMainItemPageStore;

  useLayer5DummyMainItemPageStore(() => {
    if (!store) {
      store = new DummyMainItemPageStore(
        DummyMainItemPageModule.get().service,
        Layer1Module.get().timingFactory
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
  getter?: () => DummyMainItemPageGetQueryHandler
) {
  const module = DummyMainItemPageModule.get();

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
  getter?: () => DummyMainItemPageService
) {
  const module = DummyMainItemPageModule.get();

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
  getter?: () => DummyMainItemPageStore
) {
  const module = DummyMainItemPageModule.get();

  if (getter) {
    module.storeGetter = getter;
  }

  return module.store;
}
