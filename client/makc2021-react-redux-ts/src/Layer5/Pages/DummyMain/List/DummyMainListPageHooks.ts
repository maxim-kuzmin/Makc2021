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
export function useLayer5DummyMainListPage() {
  useLayer5DummyMainListPageGetQueryHandler(() => {
    return new DummyMainListPageGetQueryHandler(
      Layer1Module.get().httpService,
      Layer5Module.get().service,
      Layer1Module.get().urlService
    );
  });

  let service: DummyMainListPageService;

  useLayer5DummyMainListPageService(() => {
    if (!service) {
      service = new DummyMainListPageService(
        DummyMainListPageModule.get().getQueryHandler
      );
    }

    return service;
  });

  let store: DummyMainListPageStore;

  useLayer5DummyMainListPageStore(() => {
    if (!store) {
      store = new DummyMainListPageStore(
        DummyMainListPageModule.get().service,
        Layer1Module.get().timingFactory
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
  getter?: () => DummyMainListPageGetQueryHandler
) {
  const module = DummyMainListPageModule.get();

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
  getter?: () => DummyMainListPageService
) {
  const module = DummyMainListPageModule.get();

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
  getter?: () => DummyMainListPageStore
) {
  const module = DummyMainListPageModule.get();

  if (getter) {
    module.storeGetter = getter;
  }

  return module.store;
}
