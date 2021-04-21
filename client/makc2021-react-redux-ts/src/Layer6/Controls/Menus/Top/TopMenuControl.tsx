// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import Nav from 'react-bootstrap/Nav';
import { LinkContainer } from 'react-router-bootstrap';
import { useLocation } from 'react-router-dom';

/**
 * Элемент управления "Верхнее меню".
 */
export function TopMenuControl() {
  const location = useLocation();

  return (
    <Nav className="justify-content-center" activeKey={location.pathname}>
      <Nav.Item>
        <Nav.Link href="/dummy-main/list">Список</Nav.Link>
      </Nav.Item>
      <Nav.Item>
        <LinkContainer to="/dummy-main/item">
          <Nav.Link>Элемент</Nav.Link>
        </LinkContainer>
      </Nav.Item>
      <Nav.Item>
        <Nav.Link href="/contacts">Контакты</Nav.Link>
      </Nav.Item>
    </Nav>
  );
}
