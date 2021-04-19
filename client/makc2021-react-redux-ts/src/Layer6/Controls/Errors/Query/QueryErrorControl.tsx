// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { QueryErrorControlProps } from './QueryErrorControlProps';

/**
 * Элемент управления "Ошибка запроса".
 */
export function QueryErrorControl({
  queryCode,
  messages
}: QueryErrorControlProps) {
  return messages && messages.length > 0 ? (
    <>
      <h3>Ошибки в запросе {queryCode}</h3>
      <ul>
        {messages.map((message) => (
          <li key={message}>{message}</li>
        ))}
      </ul>
    </>
  ) : null;
}
