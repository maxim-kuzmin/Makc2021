// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { DummyMainItemPageContext } from './DummyMainItemPageContext';

/**
 * Использовать обработчик запроса на получение страницы сущности "DummyMain" слоя "Layer5".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer5DummyMainItemPageGetQueryHandler(
  context: DummyMainItemPageContext
) {
  return context.getModule().getQueryHandler;
}

/**
 * Использовать сервис страницы сущности "DummyMain" слоя "Layer5".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer5DummyMainItemPageService(
  context: DummyMainItemPageContext
) {
  return context.getModule().service;
}

/**
 * Использовать хранилище страницы сущности "DummyMain" слоя "Layer5".
 * @param context Контекст.
 * @returns Хранилище.
 */
export function useLayer5DummyMainItemPageStore(
  context: DummyMainItemPageContext
) {
  return context.getModule().store;
}
