// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainListPageContext } from './DummyMainListPageContext';

/**
 * Использовать обработчик запроса на получение страницы сущностей "DummyMain" слоя "Layer5".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer5DummyMainListPageGetQueryHandler(
  context: DummyMainListPageContext
) {
  return context.getModule().getQueryHandler;
}

/**
 * Использовать сервис страницы сущностей "DummyMain" слоя "Layer5".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer5DummyMainListPageService(
  context: DummyMainListPageContext
) {
  return context.getModule().service;
}

/**
 * Использовать хранилище страницы сущностей "DummyMain" слоя "Layer5".
 * @param context Контекст.
 * @returns Хранилище.
 */
export function useLayer5DummyMainListPageStore(
  context: DummyMainListPageContext
) {
  return context.getModule().store;
}
