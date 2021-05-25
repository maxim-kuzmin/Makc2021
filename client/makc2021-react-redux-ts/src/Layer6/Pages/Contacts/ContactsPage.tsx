// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { Configurator } from 'src/Configurator';
import { useLayer6ContactsPageResource } from './ContactsPageHooks';

/**
 * Страница контактов.
 */
export function ContactsPage() {
  const resource = useLayer6ContactsPageResource(
    Configurator.Layer6.Pages.Contacts.module,
    Configurator.Layer1.getModule()
  );

  return (
    <>
      <Row>
        <Col>{resource.getAuthorFieldTitle()}</Col>
        <Col style={{ whiteSpace: 'nowrap' }}>
          {resource.getAuthorFieldValue()}
        </Col>
      </Row>
      <Row>
        <Col>{resource.getEmailFieldTitle()}</Col>
        <Col>maxim.kuzmin@inbox.ru</Col>
      </Row>
    </>
  );
}
