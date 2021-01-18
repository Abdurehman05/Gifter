import React, { useEffect, useState, useContext } from "react";
import { ListGroup, ListGroupItem } from "reactstrap";
import { useParams } from "react-router-dom";
import Post from "./Post";
import { UserProfileContext } from "../providers/UserProfileProvider";

const PostDetails = () => {
  const [post, setPost] = useState();
  const { id } = useParams();
  const { getToken } = useContext(UserProfileContext);

  useEffect(() => {
    getToken().then((token) =>
      fetch(`/api/Post/${id}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`, // The token gets added to the Authorization header
        },
      })
        .then((resp) => resp.json())
        .then((post) => setPost(post))
    );
  }, []);

  if (!post) {
    return null;
  }

  return (
    <div className="container">
      <div className="row justify-content-center">
        <div className="col-sm-12 col-lg-6">
          <Post post={post} />
          {/* <ListGroup>
            {post.comments.map((c) => (
              <ListGroupItem>{c.message}</ListGroupItem>
            ))}
          </ListGroup> */}
        </div>
      </div>
    </div>
  );
};

export default PostDetails;
