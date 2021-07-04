// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Alert } from 'react-bootstrap';
import { QueryNotificationItemControlProps } from './QueryNotificationItemControlProps';

/**
 * Элемент управления "Элемент извещения запроса".
 */
export function QueryNotificationItemControl({
  messages,
  title,
  variant
}: QueryNotificationItemControlProps) {
  return messages && messages.length > 0 ? (
    <Alert variant={variant}>
      <Alert.Heading>{title}</Alert.Heading>
      <ul>
        {messages.map((message) => (
          <li key={message}>{message}</li>
        ))}
      </ul>
    </Alert>
  ) : null;
}
