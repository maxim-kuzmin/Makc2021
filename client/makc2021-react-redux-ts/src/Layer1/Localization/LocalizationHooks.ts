// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import {
  DefaultNamespace,
  Namespace,
  TFunction,
  useTranslation
} from 'react-i18next';

/**
 * Использовать ресурс.
 * @param functionToCreateResource Функция создания ресурса.
 * @param ns Пространство имён.
 * @returns Ресурс.
 */
export function useResource<T, N extends Namespace = DefaultNamespace>(
  functionToCreateResource: (functionToTranslate: TFunction<N>) => T,
  ns?: N
) {
  const { t } = useTranslation(ns);

  return functionToCreateResource.call(null, t);
}
