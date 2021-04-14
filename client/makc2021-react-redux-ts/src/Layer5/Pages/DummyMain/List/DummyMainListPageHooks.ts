// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module as Layer1Module } from 'src/Layer1/Module';
import { Module as Layer5Module } from 'src/Layer5/Module';
import { DummyMainListPageService } from './DummyMainListPageService';
import { DummyMainListPageStore } from './DummyMainListPageStore';
import { DummyMainListPageGetQueryHandler } from './Queries/Get/DummyMainListPageGetQueryHandler';

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

  let serviceOfDummyMainListPage: DummyMainListPageService;

  useLayer5DummyMainListPageService(() => {
    if (!serviceOfDummyMainListPage) {
      serviceOfDummyMainListPage = new DummyMainListPageService(
        Layer5Module.get().getQueryHandlerOfDummyMainListPage
      );
    }

    return serviceOfDummyMainListPage;
  });

  let storeOfDummyMainListPage: DummyMainListPageStore;

  useLayer5DummyMainListPageStore(() => {
    if (!storeOfDummyMainListPage) {
      storeOfDummyMainListPage = new DummyMainListPageStore(
        Layer5Module.get().serviceOfDummyMainListPage
      );
    }

    return storeOfDummyMainListPage;
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
  const module = Layer5Module.get();

  if (getter) {
    module.getQueryHandlerOfDummyMainListPageGetter = getter;
  }

  return module.getQueryHandlerOfDummyMainListPage;
}

/**
 * Использовать сервис страницы сущностей "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5DummyMainListPageService(
  getter?: () => DummyMainListPageService
) {
  const module = Layer5Module.get();

  if (getter) {
    module.serviceOfDummyMainListPageGetter = getter;
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
  const module = Layer5Module.get();

  if (getter) {
    module.storeOfDummyMainListPageGetter = getter;
  }

  return module.storeOfDummyMainListPage;
}
