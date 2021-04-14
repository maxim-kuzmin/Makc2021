// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module as Layer1Module } from 'src/Layer1/Module';
import { Module as Layer5Module } from 'src/Layer5/Module';
import { DummyMainItemPageService } from './DummyMainItemPageService';
import { DummyMainItemPageStore } from './DummyMainItemPageStore';
import { DummyMainItemPageGetQueryHandler } from './Queries/Get/DummyMainItemPageGetQueryHandler';

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

  let serviceOfDummyMainItemPage: DummyMainItemPageService;

  useLayer5DummyMainItemPageService(() => {
    if (!serviceOfDummyMainItemPage) {
      serviceOfDummyMainItemPage = new DummyMainItemPageService(
        Layer5Module.get().getQueryHandlerOfDummyMainItemPage
      );
    }

    return serviceOfDummyMainItemPage;
  });

  let storeOfDummyMainItemPage: DummyMainItemPageStore;

  useLayer5DummyMainItemPageStore(() => {
    if (!storeOfDummyMainItemPage) {
      storeOfDummyMainItemPage = new DummyMainItemPageStore(
        Layer5Module.get().serviceOfDummyMainItemPage
      );
    }

    return storeOfDummyMainItemPage;
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
  const module = Layer5Module.get();

  if (getter) {
    module.getQueryHandlerOfDummyMainItemPageGetter = getter;
  }

  return module.getQueryHandlerOfDummyMainItemPage;
}

/**
 * Использовать сервис страницы сущности "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5DummyMainItemPageService(
  getter?: () => DummyMainItemPageService
) {
  const module = Layer5Module.get();

  if (getter) {
    module.serviceOfDummyMainItemPageGetter = getter;
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
  const module = Layer5Module.get();

  if (getter) {
    module.storeOfDummyMainItemPageGetter = getter;
  }

  return module.storeOfDummyMainItemPage;
}
