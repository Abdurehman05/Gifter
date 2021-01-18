import React, { useState, useContext } from "react";
import { Form, Input } from "reactstrap";
import { UserProfileContext } from "../providers/UserProfileProvider";

const PostSearch = ({ onSearch }) => {
  const { getToken } = useContext(UserProfileContext);
  const [searchTerm, setSearchTerm] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    getToken().then((token) =>
      fetch(`/api/Post/search?criterion=${searchTerm}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`, // The token gets added to the Authorization header
        },
      })
        .then((res) => res.json())
        .then((searchResults) => onSearch(searchResults))
    );
    setSearchTerm("");
  };

  return (
    <Form className="mt-4" onSubmit={handleSubmit}>
      <Input
        value={searchTerm}
        placeholder="Search by title or caption"
        onChange={(e) => setSearchTerm(e.target.value)}
      />
    </Form>
  );
};

export default PostSearch;
