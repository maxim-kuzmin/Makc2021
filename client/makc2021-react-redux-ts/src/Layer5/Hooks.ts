// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Context } from './Context';

/**
 * Использовать сервис слоя "Layer5".
 * @param context Контекст.
 * @returns Сервис.
 */
export function useLayer5Service(context: Context) {
  return context.getModule().service;
}
