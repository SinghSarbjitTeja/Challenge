import React from 'react';
import { Button, Header, Modal, Form, Input } from 'semantic-ui-react';

const style = {
    top: 20 + '%',
    bottom: 'auto',
    position: 'absolute',
    zIndex: 9000,
    left: 30 + '%',
}

class Edit extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            errors: {}
        }
        this.handleInputChange = this.handleInputChange.bind(this);
        this.saveContactCheck = this.saveContactCheck.bind(this);
    };


    handleInputChange(event) {
        let { name, value } = event.target;
        this.setState({ errors: {} });
        if (name == 'name') {
            this.props.selectedContact.name = value;
        }
        else if (name == 'email') {
            this.props.selectedContact.email = value;
        }
        else {
            this.props.selectedContact.phone = value;
        }
        this.props.selectContact(this.props.selectedContact);
    }

    render() {
        const { selectedContact } = this.props;

        return (
            <div className="overlay">
                <Modal size={'tiny'} open={this.props.showModal} style={style}>
                    <Modal.Header>Contact</Modal.Header>
                    <Modal.Content >
                        <Form>
                            <Form.Field>
                                <label>Contact Name</label>
                                <Input id="name" placeholder="Please enter contact name..." name="name" required value={selectedContact.name} id="name" onChange={(event) => this.handleInputChange(event)} />
                            </Form.Field>

                            <Form.Field>
                                <label>Contact Email</label>
                                <Input id="email" placeholder=" Please enter contact email..." name="email" required value={selectedContact.email} id="price" onChange={(event) => this.handleInputChange(event)} /> </Form.Field>

                            <Form.Field>
                                <label>Contact Phone</label>
                                <Input id="phone" placeholder=" Please enter contact phone numeric.."
                                    name="phone"
                                    required value={selectedContact.phone}
                                    id="name"
                                    onChange={(event) => this.handleInputChange(event)}
                                />
                            </Form.Field>
                        </Form>
                    </Modal.Content>
                    <Modal.Actions>
                        <Button color='grey' onClick={() => this.props.closeModal()} >Cancel</Button>
                        <Button color='blue' onClick={() => this.saveContactCheck(selectedContact)}>Save</Button>
                    </Modal.Actions>
                </Modal>
            </div>
        );
    }
}
export default Edit;

