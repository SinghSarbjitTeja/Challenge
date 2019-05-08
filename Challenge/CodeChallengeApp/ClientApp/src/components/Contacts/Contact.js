import React from 'react';
import axios from 'axios';
import ContactData from './ContactData.js';
import Edit from './edit.js';
import { Button } from 'semantic-ui-react'

class Contact extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            contactList: [],
            showModal: false,
            selectedContact: "",
            searchString : ""
        };
        this.selectContact = this.selectContact.bind(this);
        this.deleteSelectContact = this.deleteSelectContact.bind(this);
        this.saveContact = this.saveContact.bind(this);
        this.closeModal = this.closeModal.bind(this);
        this.reload = this.reload.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }
    componentDidMount() {
        this.reload();
    }

    reload() {
        let self = this;
        axios({
            method: 'get',
            url: 'http://localhost:52077/api/contact',
        })
            .then(function (res) {
                let data = res.data;
                self.setState({
                    contactList: data
                })
            })
            .catch(error => {
                console.log(error.response)
            });
    }
    closeModal() {
        this.setState({
            showModal: false
        });
    }

    selectContact(contact) {
        debugger;
        this.setState({
            selectedContact: contact,
            showModal: true
        });
    }

    addNew() {
        this.setState({
            selectedContact: {},
            showModal: true,
        });
    }

    deleteSelectContact(contact) {
        axios({
            method: 'delete',
            url: 'http://localhost:52077/api/contact/' + contact.id,
        })
            .then(function (res) {
                debugger;
                alert(res.data.message);
                //  this.reload();
                window.location.reload(true);
            })
            .catch(error => {
                console.log(error.response)
            });
    }

    saveContact(contactTobeSaved) {
        debugger;
        let self = this;
        if (contactTobeSaved.id === undefined || contactTobeSaved.id === null) {
            axios({
                method: 'post',
                url: 'http://localhost:52077/api/contact',
                data: contactTobeSaved,
            })
                .then(function (res) {
                    alert(res.data.message);
                    window.location.reload(true);
                })
                .catch(error => {
                    console.log(error.response)
                });
        }
        else {
            axios({
                method: 'put',
                url: 'http://localhost:52077/api/contact',
                data: contactTobeSaved,
            })
                .then(function (res) {
                    alert(res.data.message);

                })
                .catch(error => {
                    console.log(error.response)
                });
        }
        this.setState({
            showModal: false
        });
    }

    handleChange(event) {
        this.setState({ searchString: event.target.value });
    }

    render() {
        let filteredContactList = this.state.contactList.filter((contact) => {
            return contact.name.indexOf(this.state.searchString) !== -1;
        });

        return (
            <div >
                <input className="prompt"
                    onChange={this.handleChange}
                    onKeyPress={this.handleChange}                   
                    type="text"
                    placeholder="Search" />
                {this.state.selectedContact && <Edit selectContact={this.selectContact}
                    selectedContact={this.state.selectedContact}
                    closeModal={this.closeModal} showModal={this.state.showModal}
                    saveContact={this.saveContact} listOfContacts={this.state.contactList} />
                }
                <Button color='blue' onClick={() => this.addNew()}>Create New Contact</Button>
                <ContactData contactData={filteredContactList} selectContact={this.selectContact}
                    deleteSelectContact={this.deleteSelectContact} />
            </div>
        );
    }
}
export default Contact;






