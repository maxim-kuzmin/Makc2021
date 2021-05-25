// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Configurator } from 'src/Configurator';
import { useLayer6QueryErrorControlResource } from './QueryErrorControlHooks';
import { QueryErrorControlProps } from './QueryErrorControlProps';

/**
 * Элемент управления "Ошибка запроса".
 */
export function QueryErrorControl({
  queryCode,
  messages
}: QueryErrorControlProps) {
  const resource = useLayer6QueryErrorControlResource(
    Configurator.Layer6.Controls.Errors.Query.module,
    Configurator.Layer1.getModule()
  );

  return messages && messages.length > 0 ? (
    <>
      <h3>{resource.getTitle(queryCode)}</h3>
      <ul>
        {messages.map((message) => (
          <li key={message}>{message}</li>
        ))}
      </ul>
    </>
  ) : null;
}
